using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task24_advanced.ViewModels
{
    public class GuestViewModel
    {
        public List<GuestRoomDataViewModel> GuestRoomData { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public GuestRoomDataViewModel NewData { get; set; }

    }
}