using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _Default : Page
{
    protected static int counter =0;
    protected static Dictionary<int, String> dict = new Dictionary<int, String>();

    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Display_Tasks();
    }

    void DeleteBtn_Click(object sender, EventArgs e)
    {
        HtmlButton b = (HtmlButton)sender;
        if (b != null)
        {
            String id= b.ID;
            int index = id.IndexOf("-");
            String value = id.Substring(index + 1);
            int num =  Convert.ToInt16(value);
           
            Control c = TableContainer.FindControl(id);
            TableContainer.Controls.Remove(c);
            
            Control cb = TableContainer.FindControl("Break-"+num);
            TableContainer.Controls.Remove(cb);
            dict.Remove(num);
        }
        else
        {
            Console.WriteLine("The source of the trigger was not an HTMLButton, Ignoring..");
        } 
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        String text = RowText.Value;
        if (!dict.ContainsValue(text))
        {
            ErrorLabel.InnerHtml = "";
            try
            {
                dict.Add(counter, text);
                Add_Task(text, counter);
                counter++;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException caught!");
            }
        }
        else
        {
            ErrorLabel.InnerHtml = "Sorry, no duplicate items allowed!";
        }
    }

    void Display_Tasks()
    {
        for (int i = 0; i < counter; i++)
        {
            if (dict.ContainsKey(i))
            {
                Add_Task(null, i);
            }
        }
    }

    void Add_Task(String text, int num)
    {
        HtmlButton NewButtonControl = new HtmlButton();
        NewButtonControl.ID = "Task-" + num;
        if (text == null)
        {
            dict.TryGetValue(num, out text);
        }
        NewButtonControl.InnerHtml = text;
        NewButtonControl.ServerClick += new System.EventHandler(this.DeleteBtn_Click);

        TableContainer.Controls.Add(NewButtonControl);
        LiteralControl b = new LiteralControl("<br />");
        b.ID = "Break-" + num;
        TableContainer.Controls.Add(b);
    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < TableContainer.Controls.Count; i++)
        {
            TableContainer.Controls.RemoveAt(i);
        }
        dict.Clear();
        ErrorLabel.InnerHtml = "";
    }
}

/*
    void Display_Items()
    {
        for (int i = 0; i < dict.Count; i++)
        {
            String value = "";
            if (dict.TryGetValue(i, out value))
            {
                //HtmlContainerControl NewRow = new HtmlContainerControl();
                HtmlGenericControl NewRow = new HtmlGenericControl("div");
                NewRow.ID = "row-" + i;
                NewRow.InnerHtml = value; 
                // +"<button style=\"height:25px; width:75px\" runat=\"server\" onmouseover=\"this.style.backgroundColor='lightyellow'\" onmouseout=\"this.style.backgroundColor='lightgrey'\" onserverclick=\"DeleteBtn_Click\" id=\"Delete\"> Done </button>";
                //"<p> " + value + " </p>";
                NewRow.Attributes.Add("class", "lead");
            }
        }
    }
*/