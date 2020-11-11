using CarAuctionScraper.Domain.Values;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAuctionScraper.Domain.UnitTests.Values._Location
{
    [TestFixture]
    public class Distance
    {
        [Test]
        public void distance_is_zero_between_the_same_locations()
        {
            var loc1 = new Location(45, 90);
            var loc2 = new Location(45, 90);

            var distance = loc1.Distance(loc2);

            distance.Should().BeApproximately(0, 0.1);
        }

        [Test]
        public void distance_is_correctly_calculated_for_latitude()
        {
            var loc1 = new Location(45, 90);
            var loc2 = new Location(55, 90);

            var distance = loc1.Distance(loc2);

            distance.Should().BeApproximately(1111.95, 0.1);
        }

        [Test]
        public void distance_is_correctly_calculated_for_longitude()
        {
            var loc1 = new Location(45, 90);
            var loc2 = new Location(45, 100);

            var distance = loc1.Distance(loc2);

            distance.Should().BeApproximately(785.77, 0.1);
        }

        [Test]
        public void throws_argument_exception_when_latitude_below_minus_90()
        {
            Action action = () => new Location(-91, 90);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void throws_argument_exception_when_latitude_over_90()
        {
            Action action = () => new Location(91, 90);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void throws_argument_exception_when_longitude_below_minus_180()
        {
            Action action = () => new Location(45, -181);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void throws_argument_exception_when_longitude_over_180()
        {
            Action action = () => new Location(45, 181);

            action.Should().Throw<ArgumentException>();
        }
    }
}
