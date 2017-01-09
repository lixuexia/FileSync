using System;
using System.Data;
using System.Web.UI.WebControls;
using Home.LogUtility;
using System.Collections.Generic;

namespace Trans.Web.Display
{
    public partial class Trace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitList();
                this.Data_Bind();
            }
        }
        private void InitList()
        {
            List<string> Years = new DBLog().GetBlockYears();
            YearList.Items.Clear();
            YearList.Items.Add(new ListItem("---请选择---", "-1"));
            foreach (var YearStr in Years)
            {
                YearList.Items.Add(new ListItem(YearStr, YearStr));
            }
        }
        private void Data_Bind()
        {
            if (this.BlockList.Items.Count > 1)
            {
                DataTable DT = new DBLog().GetTraces(BlockList.SelectedItem.Value);
                TGridView.DataSource = DT;
                TGridView.DataBind();
            }
        }
        protected void BlockList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Data_Bind();
        }
        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearList.SelectedItem.Value != "-1")
            {
                DataTable DT = new DBLog().GetBlockMonthList(YearList.SelectedItem.Value);
                this.MonthList.Items.Clear();
                this.MonthList.Items.Add(new ListItem("---请选择---", "-1"));
                foreach (DataRow dr in DT.Rows)
                {
                    this.MonthList.Items.Add(new ListItem(dr["MONTH"].ToString(), dr["MONTH"].ToString()));
                }
            }
        }
        protected void TGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TGridView.PageIndex = e.NewPageIndex;
            this.Data_Bind();
        }
        protected void TGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1 && e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.background='#ccc'");
                e.Row.Attributes.Add("onmouseout", "this.style.background='#ffffff'");
            }
        }
        protected void DayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.YearList.SelectedItem.Value != "-1" && this.MonthList.SelectedItem.Value != "-1" && this.DayList.SelectedItem.Value != "-1")
            {
                DataTable DT = new DBLog().GetMarkBlocks(this.YearList.SelectedItem.Value.Trim(), this.MonthList.SelectedItem.Value.Trim(), this.DayList.SelectedItem.Value.Trim());
                this.BlockList.Items.Clear();
                this.BlockList.Items.Add(new ListItem("---请选择---", "-1"));
                foreach (DataRow dr in DT.Rows)
                {
                    this.BlockList.Items.Add(new ListItem(dr["Block"].ToString(), dr["Block"].ToString()));
                }
            }
        }
        protected void MonthList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MonthList.SelectedItem.Value != "-1" && YearList.SelectedItem.Value != "-1")
            {
                DataTable DT = new DBLog().GetBlockDayList(YearList.SelectedItem.Value, MonthList.SelectedItem.Value);
                this.DayList.Items.Clear();
                this.DayList.Items.Add(new ListItem("---请选择---", "-1"));
                foreach (DataRow dr in DT.Rows)
                {
                    this.DayList.Items.Add(new ListItem(dr["Day"].ToString(), dr["Day"].ToString()));
                }
            }
        }
    }
}