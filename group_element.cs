using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace audio_test
{
    class group_element
    {
        Control ctrl;
        Point relpos;

        public group_element(Control c, Point rpos)
        {
            ctrl = c;
            relpos = new Point();
            relpos.X = c.Location.X - rpos.X;
            relpos.Y = c.Location.Y - rpos.Y;
        }

        public void show(Point tpos)
        {
            ctrl.Location = new Point(tpos.X + relpos.X, tpos.Y + relpos.Y);
            ctrl.Visible = true;
        }

        public void hide()
        {
            ctrl.Visible = false;
        }

    }
}
