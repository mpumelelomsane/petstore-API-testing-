using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.PetStore.Swagger.Api;
using Applications.PetStore.Swagger.Client;
using Applications.PetStore.Swagger.Model;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;

namespace Applications.PetStore.Steps
{
    public class PetSteps
    {
        private readonly PetApi _petApi = new PetApi(StepsHelper.BasePath);
        private long petId = 101;

        [Step("Add a pet with a name and its category")]
        public void addPet() 
        {
            Pet pet = new Pet (
            id: petId,
            category: new Category { Id = 10, Name = "Dog"},
            name: "Cesar",
            photoUrls: new List<string> {"http://dogs.com"},
            tags: new List<Tag> {new Tag {Id = 10, Name = "Dog"}},
            status: Pet.StatusEnum.Available
            );

            _petApi.AddPet(pet);
        }

        [Step("Verify that the pet was added")]
        public void verifyPetWasAdded()
        {
            var pet = _petApi.GetPetById(petId);
            pet.Should().NotBeNull();
        }

        [Step("Delete a pet that was added to the store")]
        public void deletePet() 
        {
            _petApi.DeletePet(petId);
        }

        [Step("Verify that the pet was deleted")]
        public void verifyPetWasDeleted() 
        {
            
            Assert.Throws<ApiException>(() => {var pet = _petApi.GetPetById(petId).Should().BeNull();});
        }
    }
}            