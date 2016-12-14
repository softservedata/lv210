using System;


namespace TestApp
{
    public class ContactData
    {
        private int contactDataId;
        private String country;
        private String city;
        private String street;
        private int houseNumber;
        private int distanceToKyiv;
       



        public int ContactDataId
        {
            get { return contactDataId; }
            set { contactDataId = value; }
        }
        public String Country
        {
            get { return country; }
            set { country = value; }
        }
        public String City
        {
            get { return city; }
            set { city = value; }
        }
        public String Street
        {
            get { return street; }
            set { street = value; }
        }
        public int HouseNumber
        {
            get { return houseNumber; }
            set { houseNumber = value; }
        }
        public int DistanceToKyiv
        {
         get { return distanceToKyiv; }
        set { distanceToKyiv = value; }
        }
        public ContactData()
        {
        }
       public ContactData(int Id, string Country, string City, string Street, int HouseNumber, int DistanceToKyiv)
        {
            this.ContactDataId = Id;
            this.Country = Country;
            this.City = City;
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.DistanceToKyiv = DistanceToKyiv;

        }

        public String sideStreet(){
            return this.HouseNumber % 2 == 0 ? "Right" : "Left";
        }
        public bool isUkraine()
        {
            return this.Country.Trim() == "Ukraine" ? true : false;
        }
        public String toString()
        {
            return this.Country +" "+this.City + " "+ this.Street + " / "+ this.HouseNumber;
        }
        public bool nearTheKyiv()
        {
            return this.distanceToKyiv < 100 ? true : false;
        }
    }
}
