using BlazorPOC.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorPOC.Data
{
    public class VesselDimensionModel
    {
       

        private int _length;

        public delegate void OnLengthChanged();

        //declare event of type delegate
        public event OnLengthChanged onLengthChangedEvent;

        [Required]
        [Range(0, 100, ErrorMessageResourceName = "VesselLengthError", ErrorMessageResourceType = typeof(SharedResource))]
        public int Length
        {
            get
            {
               return  _length;
            }
            set
            {
                _length = value;

                ////call delegate method 
                //if (onLengthChangedEvent != null)
                //    onLengthChangedEvent();
            }
        }
       
        [Required(ErrorMessageResourceName = "requiredField", ErrorMessageResourceType = typeof(SharedResource))]
        [Range(0, 100, ErrorMessageResourceName = "VesselBreadthError", ErrorMessageResourceType = typeof(SharedResource))]
        public int Breadth { get; set; }

        public VesselHelper.VesselType TypeOfVessel { get; set; } = VesselHelper.VesselType.unknown;

    }
}
