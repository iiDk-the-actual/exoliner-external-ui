using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExolinerExternalUI
{
    public class FlatTabControl : TabControl
    {
        // Entirely vibecoded. There is no way to do TabControl without getting into windows bullshit

        public Color StripColor = Color.FromArgb(0x0B, 0x0F, 0x1A);
        public Color PageColor = Color.FromArgb(0x0A, 0x0A, 0x0F);
        public Color BorderColor = Color.FromArgb(55, 55, 55);
        public Color TabActiveColor = Color.FromArgb(0x3C, 0x83, 0xF6);
        public Color TabInactiveColor = Color.FromArgb(0x0D, 0x14, 0x25);

        // Set by PaintFlatChrome before each OnDrawItem call so the form
        // handler always knows exactly which index and state it is drawing.
        public int PaintingIndex = -1;
        public bool PaintingSelected = false;

        private const int TAB_GAP = 3;

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int SetWindowTheme(IntPtr hwnd, string app, string id);

        private const int WM_PAINT = 0x000F;
        private const int WM_ERASEBKGND = 0x0014;

        public FlatTabControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= ~0x200;
                return cp;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(Handle, "", "");
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ERASEBKGND) { m.Result = (IntPtr)1; return; }
            if (m.Msg == WM_PAINT)
            {
                base.WndProc(ref m);
                using (Graphics g = Graphics.FromHwnd(Handle))
                    PaintFlatChrome(g);
                return;
            }
            base.WndProc(ref m);
        }

        private void PaintFlatChrome(Graphics g)
        {
            if (TabCount == 0) return;

            Rectangle client = ClientRectangle;
            int stripH = DisplayRectangle.Top;

            // 1. Strip background.
            g.FillRectangle(new SolidBrush(StripColor), 0, 0, client.Width, stripH);

            // 2. Page content area.
            g.FillRectangle(new SolidBrush(PageColor), DisplayRectangle);

            // 3. Tab buttons.
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tr = GetTabRect(i);
                Rectangle fill = new Rectangle(tr.X, tr.Y, tr.Width - TAB_GAP, tr.Height);

                bool active = (i == SelectedIndex);
                g.FillRectangle(new SolidBrush(active ? TabActiveColor : TabInactiveColor), fill);

                // Tell the form handler exactly what it is drawing.
                PaintingIndex = i;
                PaintingSelected = active;

                OnDrawItem(new DrawItemEventArgs(g, Font, fill, i,
                    active ? DrawItemState.Selected : DrawItemState.Default));
            }

            PaintingIndex = -1;

            // 4. Flat page border.
            if (SelectedTab != null)
            {
                Rectangle page = DisplayRectangle;
                page.Inflate(1, 1);
                g.DrawRectangle(new Pen(BorderColor), page);
            }
        }
    }
}