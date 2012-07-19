using System.ComponentModel.DataAnnotations;
using System.Linq;
using DebtMan.WebApp.Mappers;
using NUnit.Framework;

namespace DebtMan.WebApp.Tests
{
    // ReSharper disable InconsistentNaming

    [TestFixture]
    internal class SelectListBuilderTests
    {
        private enum EnumWithZeroEnumerationElements
        {
        }

        private enum EnumWithOneEnumerationElement
        {
            Element1
        }

        private enum EnumWithDataAnnotations
        {
            [Display(Name = "DataAnnotation1")]
            Element1,

            [Display(Name = "DataAnnotation2")]
            Element2
        }

        private enum EnumWithSomeDataAnnotations
        {
            [Display(Name = "DataAnnotation1")]
            Element1,

            Element2,

            [Display(Name = "DataAnnotation3")]
            Element3,

            Element4
        }

        [Test]
        public void FromEnum_GivenAnEnumWithZeroEnumerationElements_ReturnsAnEmptySelectList()
        {
            // Arrange, Act
            var selectList = SelectListBuilder.FromEnum(typeof(EnumWithZeroEnumerationElements));

            // Assert
            Assert.That(selectList, Is.Empty);
        }

        [Test]
        public void FromEnum_GivenAnEnumWithOneEnumerationElement_ReturnsASelectListWithOneItem()
        {
            // Arrange, Act
            var selectList = SelectListBuilder.FromEnum(typeof(EnumWithOneEnumerationElement));

            // Assert
            Assert.That(selectList.Count(), Is.EqualTo(1));
        }

        [Test]
        public void FromEnum_GivenAnEnumWithOneEnumerationElement_ReturnsASelectListWithOneItemWithCorrectTextAndValue()
        {
            // Arrange, Act
            var selectList = SelectListBuilder.FromEnum(typeof(EnumWithOneEnumerationElement));
            var selectListItem = selectList.First();

            // Assert
            Assert.That(selectListItem.Text, Is.EqualTo("Element1"));
            Assert.That(selectListItem.Text, Is.EqualTo("Element1"));
        }

        [Test]
        // ReSharper disable PossibleMultipleEnumeration
        public void FromEnum_GivenAnEnumWithDataAnnotations_ReturnsSelectListItemsWithCorrectTextAndValueProperties()
        {
            // Arrange, Act
            var selectList = SelectListBuilder.FromEnum(typeof(EnumWithDataAnnotations));
            var item1 = selectList.Skip(0).First();
            var item2 = selectList.Skip(1).First();

            // Assert
            Assert.That(item1.Text, Is.EqualTo("DataAnnotation1"));
            Assert.That(item1.Value, Is.EqualTo("DataAnnotation1"));
            Assert.That(item2.Text, Is.EqualTo("DataAnnotation2"));
            Assert.That(item2.Value, Is.EqualTo("DataAnnotation2"));
        }
        // ReSharper restore PossibleMultipleEnumeration

        [Test]
        // ReSharper disable PossibleMultipleEnumeration
        public void FromEnum_GivenAnEnumWithSomeDataAnnotations_ReturnsSelectListItemsWithCorrectTextAndValueProperties()
        {
            // Arrange, Act
            var selectList = SelectListBuilder.FromEnum(typeof(EnumWithSomeDataAnnotations));
            var item1 = selectList.Skip(0).First();
            var item2 = selectList.Skip(1).First();
            var item3 = selectList.Skip(2).First();
            var item4 = selectList.Skip(3).First();

            // Assert
            Assert.That(item1.Text, Is.EqualTo("DataAnnotation1"));
            Assert.That(item1.Value, Is.EqualTo("DataAnnotation1"));
            Assert.That(item2.Text, Is.EqualTo("Element2"));
            Assert.That(item2.Value, Is.EqualTo("Element2"));
            Assert.That(item3.Text, Is.EqualTo("DataAnnotation3"));
            Assert.That(item3.Value, Is.EqualTo("DataAnnotation3"));
            Assert.That(item4.Text, Is.EqualTo("Element4"));
            Assert.That(item4.Value, Is.EqualTo("Element4"));
        }
        // ReSharper restore PossibleMultipleEnumeration
    }

    // ReSharper restore InconsistentNaming
}

