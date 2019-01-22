using AnimalsSupportSystem.Business.Utils.Dto;
using AnimalsSupportSystem.Infrastucture.Model;

namespace AnimalsSupportSystem.Business.Utils
{
    public static class EntityExtensions
    {
        public static AnimalRegister ToEntity(this Dto.AnimalsRegisterMapper animal)
        {
            return new AnimalRegister
            {
                Name = animal.Name,
                Age = animal.Age,
                Type = animal.Type,
                Gender = animal.Gender,
                Color = animal.Color,
                IsCleansed = false,
                DeseaseID = animal.DeseaseID,
                AdoptionCenterID = animal.AdoptionCenterID
            };
        }
        public static CleanseCenter ToEntity(this Dto.CleanseCenterMapper cleanse)
        {
            return new CleanseCenter
            {
                Address = cleanse.Address,
                Name = cleanse.Name
            };
        }
        public static AdoptionCenter ToEntity(this Dto.AdoptionCenterMapper adoption)
        {
            return new AdoptionCenter
            {
                Address = adoption.Address,
                Name = adoption.Name
            };
        }
        public static Request ToEntity(this RequestMapper request)
        {
            return new Request
            {
                RequestDate = request.RequestDate,
                IsClosed = false,
                Reciever = new Reciever
                {
                    FirstName = request.Reciever.FirstName,
                    LastName = request.Reciever.LastName,
                    Age = request.Reciever.Age,
                    Address = request.Reciever.Address
                },
                RequestDetails = new RequestDetails
                {
                    AnimalType = request.RequestDetails.AnimalType,
                    Gender = request.RequestDetails.Gender,
                    MinAge = request.RequestDetails.MinAge,
                    MaxAge = request.RequestDetails.MaxAge,
                    Color = request.RequestDetails.Color
                }
            };
        }
    }
}
