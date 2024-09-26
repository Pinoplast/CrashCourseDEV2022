using SmartHouseModels;
namespace TestProjectSmartHouse
{
    public class UnitTestSmartHouseModel
    {
        #region Test_House_Temperature
        [Fact]
        public void TestAirCondionerOn()
        {
            AirConditioner conditioner = new AirConditioner();
            conditioner.Power();
            Assert.True(conditioner.On);

        }
        [Fact]
        public void TestAirCondionerOff()
        {
            AirConditioner conditioner = new AirConditioner();

            Assert.False(conditioner.On);

        }
        [Fact]
        public void TestTemperatureHouseInRangeFromHot()
        {
            House house = new House();
            house.Temperature = 42; // the temperature should decrease to the range 18..25 
            int tempMin = house.TemperatureSensor.DesireMinTemperature;
            int tempMax = house.TemperatureSensor.DesireMaxTemperature;

            Assert.InRange(house.Temperature, tempMin, tempMax);

        }
        [Fact]
        public void TestTemperatureHouseInRangeFromCold()
        {
            House house = new House();
            house.Temperature = -42; // the temperature should increase to the range 18..25 
            int tempMin = house.TemperatureSensor.DesireMinTemperature;
            int tempMax = house.TemperatureSensor.DesireMaxTemperature;

            Assert.InRange(house.Temperature, tempMin, tempMax);

        }
        [Fact]
        public void TestAirConditionModeFromHot()
        {
            House house = new House();
            house.Temperature = 42;

            AirCondMode airConditionerMode = house.AirConditioner.Mode;
            Assert.Equal(AirCondMode.Cool, airConditionerMode);

        }
        [Fact]
        public void TestAirConditionModeFromCold()
        {
            House house = new House();
            house.Temperature = -42;

            AirCondMode airConditionerMode = house.AirConditioner.Mode;
            Assert.Equal(AirCondMode.Warm, airConditionerMode);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(15)]
        public void TestAirConditionModeFromColdReturnsWarm(int temperature)
        {
            House house = new House();
            house.Temperature = temperature;

            AirCondMode airConditionerMode = house.AirConditioner.Mode;
            Assert.Equal(AirCondMode.Warm, airConditionerMode);

        }


        #endregion TestHouseTemperature
        #region TestHouseLamp
        [Fact]
        public void TestLuxAndNotMotionReturnLampOff()
        {
            House house = new House(20, 100);
            house.MotionSensor.IsMoving = false;
            Assert.False(house.Lamp.On);

        }
        [Fact]
        public void TestLowLuxAndNotMotionReturnLampOff()
        {
            House house = new House(20, 30);
            house.MotionSensor.IsMoving = false;
            Assert.False(house.Lamp.On);

        }
        [Fact]
        public void TestLuxAndMotionReturnLampOff()
        {
            House house = new House(20, 100);
            house.MotionSensor.IsMoving = true;
            Assert.False(house.Lamp.On);

        }
        [Fact]
        public void TestLowLuxAndMotionReturnLampOn()
        {
            House house = new House(20, 30);
            house.MotionSensor.IsMoving = true;
            house.Lux = 10;
            Assert.True(house.Lamp.On);

        }

        #endregion TestHouseLamp
    }
}