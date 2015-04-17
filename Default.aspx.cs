using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _Default : Page
{
    protected static int counter =1;
    protected static Dictionary<int, String> dict = new Dictionary<int, String>();

    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {    
    }

    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        String nameOfButton = e.ToString(); //(sender as HtmlButton.);
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        int count = dict.Count;
        String text = RowText.Value;
        if (!dict.ContainsValue(text))
        {
            ErrorLabel.InnerHtml = "";
            try
            {
                dict.Add(count, text);
            }
            catch (ArgumentException a) 
            {
                Console.WriteLine("ArgumentException caught!");
            }
        }
        else
        {
            ErrorLabel.InnerHtml = "Sorry, no duplicate items allowed!";
        }

        for (int i = 0; i < dict.Count; i++)
        {
            String value = "";
            if (dict.TryGetValue(i, out value))
            {
                HtmlGenericControl NewRow = new HtmlGenericControl("div");
                NewRow.ID = "row-" + i;
                NewRow.InnerHtml = "<p> " + value + " </p>";
                NewRow.Attributes.Add("class", "lead"); //col-md-4

                HtmlButton NewButtonControl = new HtmlButton();
                NewButtonControl.ID = "Delete-"+i;
                NewButtonControl.InnerHtml = "Done";
                NewButtonControl.ServerClick += new System.EventHandler(this.DeleteBtn_Click);
                NewRow.Controls.Add(NewButtonControl);

                TableContainer.Controls.Add(NewRow);
                TableContainer.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
} 