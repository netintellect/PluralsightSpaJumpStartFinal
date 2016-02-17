using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.WordsProcessing.Replace
{
    public enum ReplaceOption
    {
        [Display(Name = "Replace Text")]
        ReplaceText,

        [Display(Name = "Replace Styling")]
        ReplaceStyling
    }
}
