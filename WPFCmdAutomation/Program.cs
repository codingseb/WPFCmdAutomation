using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation = System.Windows.Automation;
using System.Windows.Automation;

namespace WPFCmdAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AutomationElement rootElement = AutomationElement.RootElement;

                if(rootElement != null)
                {
                    AutomationElement appElement = null;

                    appElement = rootElement.FindFirst(TreeScope.Children, 
                        new PropertyCondition(AutomationElement.NameProperty
                            , args[1].ToLower().Trim('"')
                            , PropertyConditionFlags.IgnoreCase));


                    string function = args[0].ToLower().Trim('"');

                    if(function.Equals("settext"))
                    {
                        AutomationElement txt = GetElementByName(appElement, args[2].Trim('"'));

                        if (txt != null)
                        {
                            ValuePattern pattern = txt.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

                            pattern.SetValue(args[3].Trim('"'));

                            TextPattern textPattern = txt.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

                            textPattern.GetVisibleRanges()[0].Select();
                        }
                    }
                }
            }
            catch
            {}
        }

        private static AutomationElement GetElementByName(AutomationElement parentElement, string value)
        {
            Automation.Condition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, value);
            AutomationElement txtElement = parentElement.FindFirst(TreeScope.Descendants, condition);
            return txtElement;
        }

    }
}
