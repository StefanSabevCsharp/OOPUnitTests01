using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_1()
        {
            Assert.Pass();
        }
        [Test]
        public void GarageCtorTest()
        {
            Garage garage = new Garage(10);
            Assert.AreEqual(10, garage.Capacity);
        }
        [Test]
        public void AddVehicleTest()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            Assert.AreEqual(1, garage.Vehicles.Count);
        }
        [Test]
        public void AddVehicleTestWithFullCapacity()
        {
            Garage garage = new Garage(1);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(vehicle));

        }
        [Test]
        public void AddVehicleTestWithSameLicensePlate()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            Vehicle vehicle2 = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(vehicle2));

        }
        [Test]
        public void ChargeVehiclesTest()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            Vehicle vehicle2 = new Vehicle("BMW", "X5", "CA1235");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            vehicle.BatteryLevel = 50;
            vehicle2.BatteryLevel = 50;
            garage.ChargeVehicles(100);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }
        [Test]
        public void ChargeVehiclesTestWithNoVehicles()
        {
            Garage garage = new Garage(10);
            garage.ChargeVehicles(100);
            Assert.AreEqual(0, garage.ChargeVehicles(100));
        }
        [Test]
        public void DriveVehicleTest()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, false);
            Assert.AreEqual(50, vehicle.BatteryLevel);
        }
        [Test]
        public void DriveVehicleTestWithAccident()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, true);
            Assert.AreEqual(50, vehicle.BatteryLevel);
            Assert.IsTrue(vehicle.IsDamaged);
        }
        [Test]
        public void DriveVehicleTestWithBatteryDrainage()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 150, false);
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }
        [Test]
        public void DriveVehicleTestWithBatteryDrainageWithDamagedVehicle()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            vehicle.IsDamaged = true;
            garage.DriveVehicle("CA1234", 50, false);
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }
        [Test]
        public void DriveVehicleTestReduceBatteryLevel()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, false);
            Assert.AreEqual(50, vehicle.BatteryLevel);
        }
        [Test]
        public void RepairVehicleTest()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            vehicle.IsDamaged = true;
            garage.RepairVehicles();
            Assert.IsFalse(vehicle.IsDamaged);
        }
        [Test]
        public void RepairVehicleTestWithNoDamagedVehicles()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.RepairVehicles();
            Assert.IsFalse(vehicle.IsDamaged);
        }
        [Test]
        public void ChargeVehiclesTestChangeBatteryLevel()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            Vehicle vehicle2 = new Vehicle("BMW", "X5", "CA1235");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            vehicle.BatteryLevel = 50;
            vehicle2.BatteryLevel = 50;
            garage.ChargeVehicles(100);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }

        [Test]
        public void VehicleCtorTest()
        {
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            Assert.AreEqual("BMW", vehicle.Brand);
            Assert.AreEqual("X5", vehicle.Model);
            Assert.AreEqual("CA1234", vehicle.LicensePlateNumber);
        }

        [Test]
        public void VehicleIsDamagedTest()
        {
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            vehicle.IsDamaged = true;
            Assert.IsTrue(vehicle.IsDamaged);
        }
        [Test]
        public void VehicleBatteryLevelTest()
        {
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            vehicle.BatteryLevel = 50;
            Assert.AreEqual(50, vehicle.BatteryLevel);
        }
        [Test]
        public void VehicleIsDamagedTestWithDriveVehicleMethod()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, true);
            Assert.IsTrue(vehicle.IsDamaged);
        }
        [Test]
        public void VehicleBatteryLevelTestWithDriveVehicleMethod()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, false);
            Assert.AreEqual(50, vehicle.BatteryLevel);
        }

        [Test]
        public void VehicleIsDamagedTestWithRepairVehicleMethod()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.RepairVehicles();
            Assert.IsFalse(vehicle.IsDamaged);
        }
        [Test]
        public void VehicleBatteryLevelTestWithChargeVehicleMethod()
        {
            Garage garage = new Garage(10);
            Vehicle vehicle = new Vehicle("BMW", "X5", "CA1234");
            vehicle.BatteryLevel = 50;
            garage.AddVehicle(vehicle);
            garage.ChargeVehicles(100);
            Assert.AreEqual(100, vehicle.BatteryLevel);
        }
       

        [Test]
        public void VehicleIsDamagedTest2()
        {
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            vehicle.IsDamaged = true;
            Assert.IsTrue(vehicle.IsDamaged);
        }

        [Test]
        public void VehicleBatteryLevelTest3()
        {
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            vehicle.BatteryLevel = 50;
            Assert.AreEqual(50, vehicle.BatteryLevel);
        }
        [Test]
        public void VehicleBatteryLevelTestWithDriveVehicleMethod4()
        {
            var garage = new Garage(10);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, false);
            Assert.AreEqual(50, vehicle.BatteryLevel);
        }
        [Test]
        public void VehicleIsDamagedTestWithDriveVehicleMethod5()
        {
            var garage = new Garage(10);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("CA1234", 50, true);
            Assert.IsTrue(vehicle.IsDamaged);
        }
        [Test]
        public void VehicleIsDamagedTestWithRepairVehicleMethod6()
        {
            var garage = new Garage(10);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.RepairVehicles();
            Assert.IsFalse(vehicle.IsDamaged);
        }
        //test addVehicle returning false
        [Test]
        public void AddVehicleTest2()
        {
            var garage = new Garage(1);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            var vehicle2 = new Vehicle("Audi", "Q1", "CA1235");
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(vehicle2));
        }
        //test chargeVehicles() when it is in if statement
        [Test]
        public void ChargeVehiclesTest2()
        {
            var garage = new Garage(10);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            var vehicle2 = new Vehicle("Audi", "Q1", "CA1235");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            vehicle.BatteryLevel = 50;
            vehicle2.BatteryLevel = 50;
            garage.ChargeVehicles(100);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }
        //test chargeVehicles() when it is in else statement
        [Test]
        public void ChargeVehiclesTest3()
        {
            var garage = new Garage(10);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            var vehicle2 = new Vehicle("Audi", "Q1", "CA1235");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            vehicle.BatteryLevel = 50;
            vehicle2.BatteryLevel = 50;
            garage.ChargeVehicles(100);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }
        //testing ChargeVehicles updating the charge status
        [Test]
        public void ChargeVehiclesTest4()
        {
            var garage = new Garage(10);
            var vehicle = new Vehicle("Audi", "Q1", "CA1234");
            var vehicle2 = new Vehicle("Audi", "Q1", "CA1235");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            vehicle.BatteryLevel = 50;
            vehicle2.BatteryLevel = 50;
            garage.ChargeVehicles(100);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(100, vehicle2.BatteryLevel);
        }
    }
}