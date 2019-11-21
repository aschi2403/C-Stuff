using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Car_Database.Model
{
    public class CarMake
    {
        public int CarMakeId { get; set; }
        public string Make { get; set; }
    }

    public class CarModel
    {
        public int CarModelId { get; set; }
        public string Model { get; set; }
        public CarMake CarMake { get; set; }
        public List<Ownership> Ownerships { get; set; }
    }

    public class Ownership
    {
        public int CarModelId { get; set; }
        [Required]
        public CarModel CarModel { get; set; }
        public int PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public string VehicleIdentificationNumber { get; set; }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Ownership> Ownerships { get; set; }

        public Person()
        {
            this.Ownerships = new List<Ownership>();
        }
    }
}
