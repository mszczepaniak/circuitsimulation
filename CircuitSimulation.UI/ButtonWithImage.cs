using System.Windows.Forms;

namespace CircuitSimulation.UI
{
    public class ButtonWithImage : Button 
    {
        public ButtonWithImage()
        {
            this.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Image = Images.FormRunHS;
        }         
    }
}