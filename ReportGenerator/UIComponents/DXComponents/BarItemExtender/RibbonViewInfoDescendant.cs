using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraBars.Ribbon;

namespace CustomRibbonControl
{
	public class RibbonViewInfoDescendant : RibbonViewInfo {
        
        public RibbonViewInfoDescendant(RibbonControl ribbon)
            : base(ribbon) {
        }
        protected override RibbonPageGroupLayoutCalculator CreateGroupLayoutCalculator(RibbonPageGroupViewInfo pageInfo) {
            return new RibbonPageGroupComplexLayoutCalculatorDescendant(pageInfo);
        }
    }
}
