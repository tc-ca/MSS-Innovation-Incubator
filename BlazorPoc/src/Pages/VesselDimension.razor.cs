using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorPOC.Components;
using BlazorPOC.Controllers;
using BlazorPOC.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace BlazorPOC.Pages
{
    public class VesselDimensionBase : BasePageComponent
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected VesselDimensionModel vesselDimensionModel = new VesselDimensionModel();
        protected GrossTonnage grossTonnage;

        protected override void OnInitialized()
        {
            vesselDimensionModel.onLengthChangedEvent += OnLengthChangedEvent;
            SetSwitchLanguage();
        }
        protected bool shouldPreventDefault;
        protected void KeyHandler(KeyboardEventArgs e)
        {
            if (e.Key == "e")
            {
                shouldPreventDefault = true;
            }
            else
            {
                shouldPreventDefault = false;
            }
        }
        protected void OnLengthChangedEvent()
        {
            grossTonnage.CalculateGrossTonnage();
        }

        protected void HandleValidSubmit()
        {

            Console.WriteLine("OnValidSubmit");
        }

        protected async void OnBlurLengthCalculate(FocusEventArgs args)
        {


            //var length = args.Value.ToString();
            //grossTonnage.length = vesselDimensionModel.Length;
            grossTonnage.CalculateGrossTonnage();

                    if (vesselDimensionModel.Length > 12 && vesselDimensionModel.Length <= 15)
            {
                await JSRuntime.InvokeVoidAsync("focusElement", "vesselBreadth");
            }

        }

        protected void OnBlurCalculate(FocusEventArgs args)
        {
            //var length = args.Value.ToString();
            //grossTonnage.length = vesselDimensionModel.Length;
            var type = vesselDimensionModel.TypeOfVessel;
            grossTonnage.CalculateGrossTonnage();
        }

        protected void OnChangeCalculate()
        {
            //var length = args.Value.ToString();
            //grossTonnage.length = vesselDimensionModel.Length;
            var type = vesselDimensionModel.TypeOfVessel;
            grossTonnage.CalculateGrossTonnage();
        }

        protected void VesselHasChanged()
        {
            var temp = "somethingchanged";
        }
    }
}
