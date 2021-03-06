using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraBars;

namespace CustomRibbonControl
{
	[ProvideProperty("Location", typeof(BarItem))]
    public class BarItemExtender : Component, IExtenderProvider {
        Dictionary<BarItem, Point> controlsDictionary = new Dictionary<BarItem, Point>();
        public event EventHandler LocationChanged;

        public Point GetLocation(BarItem control) {
            Point location = Point.Empty; 
            if (controlsDictionary.ContainsKey(control)) {
                location = controlsDictionary[control];
            }
            return location;
        }
        public void SetLocation(BarItem control, Point value) {
            if (!controlsDictionary.ContainsKey(control)) {
                controlsDictionary.Add(control, value);
            }
            else {
                controlsDictionary.Remove(control);
                controlsDictionary.Add(control, value);
            }
            if (LocationChanged != null)
                LocationChanged(this, EventArgs.Empty);
        }

        #region IExtenderProvider Members

        public bool CanExtend(object control) {
            return control is BarItem;
        }
        #endregion
    }
}
