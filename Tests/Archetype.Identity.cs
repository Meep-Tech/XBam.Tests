﻿using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Archetype {
    [TestClass]
    public class Identity {

      /// <summary>
      /// Get a static id
      /// </summary>
      [TestMethod]
      public void Equals_Success() {
        Assert.AreEqual(Apple.Id, Apple.Id);
        Assert.AreEqual(Axe.Id, Axe.Id);
      }

      /// <summary>
      /// Get a static id
      /// </summary>
      [TestMethod]
      public void NotEquals_Success() {
        Assert.AreNotEqual(HealingPotion.Id, Apple.Id.Key);
      }

      /// <summary>
      /// Get a static id
      /// </summary>
      [TestMethod]
      public void StaticIdGet_Success() {
        Assert.AreEqual("Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Apple", Apple.Id.Key);
      }

      /// <summary>
      /// Get a static id
      /// </summary>
      [TestMethod]
      public void StaticIdGetFromString_Success() {
        Assert.AreEqual("Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Apple", Archetypes.Id["Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Apple"].Key);
      }

      /// <summary>
      /// Get a static id
      /// </summary>
      [TestMethod]
      public void AutoGeneratedIdentityGettable_Success() {
        Assert.AreEqual("Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Watermelon", Archetypes.Id["Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Watermelon"].Key);
      }
    }
  }
}
