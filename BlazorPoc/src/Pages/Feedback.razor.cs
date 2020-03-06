using BlazorPOC.Controllers;
using BlazorPOC.Data;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPOC.Pages
{
    public class FeedbackBase : BasePageComponent
    {
        protected string OkayDisabled { get; set; } = "disabled";
        protected EditContext EditContext;

        protected string StatusMessage;
        protected string StatusClass;

        protected FeedbackEntry Model = new FeedbackEntry();

        protected void HandleValidSubmit()
        {
            StatusClass = "alert-info";
            StatusMessage = DateTime.Now + " Handle valid submit";
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            StatusMessage = DateTime.Now + " Handle invalid submit";
        }

        protected override void OnInitialized()
        {
            SetSwitchLanguage();
            EditContext = new EditContext(Model);
            EditContext.OnFieldChanged += EditContext_OnFieldChanged;
            base.OnInitialized();
        }
       
        //protected override void OnAfterRender()
        //{
        //    base.OnAfterRender();

        //    SetOkDisabledStatus();
        //}

        private void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            SetOkDisabledStatus();
        }

        private void SetOkDisabledStatus()
        {
            if (EditContext.Validate())
            {
                OkayDisabled = null;
            }
            else
            {
                OkayDisabled = "disabled";
            }
        }

    }
}
