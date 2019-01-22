using System;
using System.Collections.Generic;

namespace AnimalsSupportSystem.Business.Utils.Dto
{
    public class CommandsMapper
    {
        public ICollection<RequestMapper> Requests { get; set; }
        public ICollection<CleanseAssignmentMapper> AssignToCleanse { get; set; }
        public ICollection<CleanseByAdoptionCenterMapper> CleanseByAdoptionCenters { get; set; }
        public ICollection<AdoptionCenterMapper> AdoptionCenters { get; set; }
        public ICollection<CleanseCenterMapper> CleanseCenters { get; set; }
        public ICollection<AnimalsRegisterMapper> AnimalsRegisters { get; set; }
      
        
        
        
        //public CommandsMapper()
        //{
        //    Requests = new List<Request>
        //    {
        //        new Request
        //        {
        //             RequestDate = DateTimeOffset.Now,
        //             IsClosed = false,
        //             Reciever = new Reciever
        //             {
        //                 FirstName = "Jhon",
        //                 LastName = "Doe",
        //                 Age = 25,
        //                 Address = "Ilionis Arizona"
        //             },
        //             RequestDetails = new RequestDetails
        //             {
        //                 AnimalType = "Dog",
        //                 Gender = "Male",
        //                 MinAge = 2,
        //                 MaxAge = 4,
        //                 Color = "black"
        //             }
        //        },
        //        new Request
        //        {
        //             RequestDate = DateTimeOffset.Now,
        //             IsClosed = false,
        //             Reciever = new Reciever
        //             {
        //                 FirstName = "Rohn",
        //                 LastName = "Wallmer",
        //                 Age = 25,
        //                 Address = "Vancuver Canada"
        //             },
        //             RequestDetails = new RequestDetails
        //             {
        //                 AnimalType = "Dog",
        //                 Gender = "Female",
        //                 MinAge = 2,
        //                 MaxAge = 4,
        //                 Color = "White"
        //             }
        //        },
        //    };
        //    AssignToCleanse = new List<CleanseAssignment>
        //    {
        //        new CleanseAssignment
        //        {
        //            CleanseCenter = "Happy-Cleanse Center",
        //            Animals = new List<int> { 2, 3, 4, 5, 6 }
        //        },
        //        new CleanseAssignment
        //        {
        //            CleanseCenter = "Animals-Cleanse Center",
        //            Animals = new List<int> { 56, 321, 567 }
        //        }
        //    };
        //    CleanseByAdoptionCenters = new List<CleanseByAdoptionCenter>
        //    {
        //        new CleanseByAdoptionCenter
        //        {
        //            CleanseCenter = "Happy-Cleanse Center",
        //            Animals = new List<int> { 2, 3, 4, 5, 6 }
        //        },
        //        new CleanseByAdoptionCenter
        //        {
        //            CleanseCenter = "Animals-Cleanse Center",
        //            Animals = new List<int> { 56, 321, 567 }
        //        }
        //    };
        //    AdoptionCenters = new List<AdoptionCenter>
        //    {
        //        new AdoptionCenter
        //        {
        //            Name = "Find-Home center",
        //            Address = ""
        //        }
        //    };
        //    CleanseCenters = new List<CleanseCenter>
        //    {
        //        new CleanseCenter
        //        {
        //            Name = "Animals-helper",
        //            Address = "Street awanue"
        //        }
        //    };
        //    AnimalsRegisters = new List<AnimalsRegister>
        //    {
        //        new AnimalsRegister
        //        {
        //            Name = "Pursy",
        //            Age = 3,
        //            Type = "Dog",
        //            Gender = "Male",
        //            Color = "Broun",
        //            IsCleansed = false,
        //            DeseaseID = 1,
        //            AdoptionCenterID = 3
        //        }
        //    };
        //}
    }
}