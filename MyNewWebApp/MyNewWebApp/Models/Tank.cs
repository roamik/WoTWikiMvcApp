using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyNewWebApp.Models
{
    public class Tank
    {
        public int TankId { get; set; }

        public int TankLevel { get; set; }

        public string TankName { get; set; }

        public string TankNation { get; set; }

        public string TankDescription { get; set; }

        public int ImageId { get; set; }

        public string ImageName { get; set; } // название картинки

        public byte[] Image { get; set; }

    }
}