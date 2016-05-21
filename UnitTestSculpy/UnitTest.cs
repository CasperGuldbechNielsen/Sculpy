using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer;
using Sculpy.Model;
using Assert = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.Assert;

namespace UnitTestSculpy
{
    [TestClass]
    public class SculptureUnitTest
    {
        private int _sculptureId;
        private string _sculptureName;
        private string _sculpturePlacement;
        private string _sculptureAddress;
        private string _sculptureDescription;
        private string _sculptureInspectionFrequency;
        private string _sculpturePicture;
        private string _sculptureCulturalHeritage;
        private DateTime _sculptureLastInspection;
        private List<string> _sculptureTypes;
        private List<Material> _sculptureMaterials;

        private Sculpture _testSculpture;
        [TestInitialize]
        public void Setup()
        {
            _testSculpture = new Sculpture();
        }


        [TestMethod]
        public void TestNormalId()
        {
            //Arrange
            _sculptureId = 7;

            //Act
            _testSculpture.ID = _sculptureId;

            //Assert
            Assert.AreEqual(_sculptureId, _testSculpture.ID);
        }

        [TestMethod]
        public void TestZeroId()
        {
            //Arrange
            _sculptureId = 0;

            //Act
            Action action = () => _testSculpture.ID = _sculptureId;

            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(action);
        }

        [TestMethod]
        public void TestName()
        {
            //Arrange
            _sculptureName = "Skulptur";

            //Act
            _testSculpture.Sculpture_Name = _sculptureName;

            //Assert
            Assert.AreEqual(_sculptureName, _testSculpture.Sculpture_Name);
        }

        [TestMethod]
        public void TestNullName()
        {
            //Arrange
            _sculptureName = null;

            //Act
            Action action = () => _testSculpture.Sculpture_Name = _sculptureName;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestShortName()
        {
            //Arrange
            _sculptureName = "AB";

            //Act
            Action action = () => _testSculpture.Sculpture_Name = _sculptureName;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestPlacement()
        {
            //Arrange
            _sculpturePlacement = "Ground";

            //Act
            _testSculpture.Sculpture_Placement = _sculpturePlacement;

            //Assert
            Assert.AreEqual(_sculpturePlacement, _testSculpture.Sculpture_Placement);
        }

        [TestMethod]
        public void TestEmptyPlacement()
        {
            //Arrange
            _sculpturePlacement = string.Empty;

            //Act
            Action action = () => _testSculpture.Sculpture_Placement = _sculpturePlacement;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestNullPlacement()
        {
            //Arrange
            _sculpturePlacement = null;

            //Act
            Action action = () => _testSculpture.Sculpture_Placement = _sculpturePlacement;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestShortPlacement()
        {
            //Arrange
            _sculpturePlacement = "AB";

            //Act
            Action action = () => _testSculpture.Sculpture_Placement = _sculpturePlacement;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestAddress()
        {
            //Arrange
            _sculptureAddress = "Frederiksberg";

            //Act
            _testSculpture.Sculpture_Address = _sculptureAddress;

            //Assert
            Assert.AreEqual(_sculptureAddress, _testSculpture.Sculpture_Address);
        }

        [TestMethod]
        public void TestEmptyAddress()
        {
            //Arrange
            _sculptureAddress = string.Empty;

            //Act
            Action action = () => _testSculpture.Sculpture_Address = _sculptureAddress;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestNullAddress()
        {
            //Arrange
            _sculptureAddress = null;

            //Act
            Action action = () => _testSculpture.Sculpture_Address = _sculptureAddress;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestShortAddress()
        {
            //Arrange
            _sculptureAddress = "AB";

            //Act
            Action action = () => _testSculpture.Sculpture_Address = _sculptureAddress;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestDescription()
        {
            //Arrange
            _sculptureDescription = "The most important sculpture in the North of Copenhagen.";

            //Act
            _testSculpture.Sculpture_Description = _sculptureDescription;

            //Assert
            Assert.AreEqual(_sculptureDescription, _testSculpture.Sculpture_Description);
        }

        [TestMethod]
        public void TestEmptyDescription()
        {
            //Arrange
            _sculptureDescription = string.Empty;

            //Act
            _testSculpture.Sculpture_Description = _sculptureDescription;

            //Assert
            Assert.AreEqual( _sculptureDescription, _testSculpture.Sculpture_Description);
        }

        [TestMethod]
        public void TestNullDescription()
        {
            //Arrange
            _sculptureDescription = null;

            //Act
            _testSculpture.Sculpture_Description = _sculptureDescription;

            //Assert
            Assert.AreEqual( _sculptureDescription, _testSculpture.Sculpture_Description);
        }

        [TestMethod]
        public void TestShortDescription()
        {
            //Arrange
            _sculptureDescription = "AB";

            //Act
            _testSculpture.Sculpture_Description = _sculptureDescription;

            //Assert
            Assert.AreEqual(_sculptureDescription, _testSculpture.Sculpture_Description);
        }

        [TestMethod]
        public void TestInspectionFrequency()
        {
            //Arrange
            _sculptureInspectionFrequency = "Twice per year.";

            //Act
            _testSculpture.Sculpture_Inspection_Frequency = _sculptureInspectionFrequency;

            //Assert
            Assert.AreEqual(_sculptureInspectionFrequency, _testSculpture.Sculpture_Inspection_Frequency);
        }

        [TestMethod]
        public void TestEmptyInspectionFrequency()
        {
            //Arrange
            _sculptureInspectionFrequency = string.Empty;

            //Act
            _testSculpture.Sculpture_Inspection_Frequency = _sculptureInspectionFrequency;

            //Assert
            Assert.AreEqual(_sculptureInspectionFrequency, _testSculpture.Sculpture_Inspection_Frequency);
        }

        [TestMethod]
        public void TestNullInspectionFrequency()
        {
            //Arrange
            _sculptureInspectionFrequency = null;

            //Act
            _testSculpture.Sculpture_Inspection_Frequency = _sculptureInspectionFrequency;

            //Assert
            Assert.AreEqual(_sculptureInspectionFrequency, _testSculpture.Sculpture_Inspection_Frequency);
        }

        [TestMethod]
        public void TestSculpturePicture()
        {
            //Arrange
            _sculpturePicture = "..//Assets//picture.png";

            //Act
            _testSculpture.Sculpture_Picture = _sculpturePicture;

            //Assert
            Assert.AreEqual(_sculpturePicture,_testSculpture.Sculpture_Picture);
        }

        [TestMethod]
        public void TestEmptySculpturePicture()
        {
            //Arrange
            _sculpturePicture = string.Empty;

            //Act
            _testSculpture.Sculpture_Picture = _sculpturePicture;

            //Assert
            Assert.AreNotEqual( _sculpturePicture, _testSculpture.Sculpture_Picture);
        }

        [TestMethod]
        public void TestNullSculpturePicture()
        {
            //Arrange
            _sculpturePicture = null;

            //Act
            _testSculpture.Sculpture_Picture = _sculpturePicture;

            //Assert
            Assert.AreEqual( _sculpturePicture, _testSculpture.Sculpture_Picture);
        }

        [TestMethod]
        public void TestSculptureCulturalHeritage()
        {
            //Arrange
            _sculptureCulturalHeritage = "High";

            //Act
            _testSculpture.Cultural_Heritage = _sculptureCulturalHeritage;

            //Assert
            Assert.AreEqual(_sculptureCulturalHeritage, _testSculpture.Cultural_Heritage);
        }

        [TestMethod]
        public void TestEmptySculptureCulturalHeritage()
        {
            //Arrange
            _sculptureCulturalHeritage = string.Empty;

            //Act
            Action action = () => _testSculpture.Cultural_Heritage = _sculptureCulturalHeritage;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestNullSculptureCulturalHeritage()
        {
            //Arrange
            _sculptureCulturalHeritage = null;

            //Act
            Action action = () => _testSculpture.Cultural_Heritage = _sculptureCulturalHeritage;

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestSculptureLastInspection()
        {
            // Arrange
            _sculptureLastInspection = DateTime.Today;

            // Act
            _testSculpture.LastInspection = _sculptureLastInspection;

            // Assert
            Assert.AreEqual(_sculptureLastInspection, _testSculpture.LastInspection);
        }

        [TestMethod]
        public void TestSculptureWrongLastInspection()
        {
            // Arrange
            _sculptureLastInspection = DateTime.Today.AddDays(1);

            // Act
            Action action = () => _testSculpture.LastInspection = _sculptureLastInspection;

            // Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestSculptureTypes()
        {
            // Arrange
            _sculptureTypes = new List<string> { "Skulptur" };

            // Act
            _testSculpture.SculptureTypes = _sculptureTypes;

            // Assert
            Assert.AreEqual(_sculptureTypes, _testSculpture.SculptureTypes);
        }

        [TestMethod]
        public void TestSculptureZeroTypes()
        {
            // Arrange
            _sculptureTypes = new List<string>() { };

            // Act
            Action action = () => _testSculpture.SculptureTypes = _sculptureTypes;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void TestSculptureMoreTypes()
        {
            // Arrange
            _sculptureTypes = new List<string>(6);

            // Act
            Action action = () => _testSculpture.SculptureTypes = _sculptureTypes;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void TestSculptureMaterials()
        {
            // Arrange
            _sculptureMaterials = new List<Material>() { new Material("Marmor") };

            // Act
            _testSculpture.SculptureMaterials = _sculptureMaterials;

            // Assert
            Assert.AreEqual(_sculptureMaterials, _testSculpture.SculptureMaterials);
        }

        [TestMethod]
        public void TestSculptureZeroMaterials()
        {
            // Arrange
            _sculptureMaterials = new List<Material>();

            // Act
            Action action = () => _testSculpture.SculptureMaterials = _sculptureMaterials;

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }

        [TestMethod]
        public void TestSculptureMoreMaterials()
        {
            // Arrange
            _sculptureMaterials = new List<Material>(17);

            // Act
            Action action = () => _testSculpture.SculptureMaterials = _sculptureMaterials;

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }
    }
}
