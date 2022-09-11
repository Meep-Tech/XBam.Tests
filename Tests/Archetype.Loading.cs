﻿using Meep.Tech.XBam.Configuration;
using Meep.Tech.XBam.Examples.Enumerations;
using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Meep.Tech.XBam.Examples.SplayedArchetype;
using Meep.Tech.XBam.Examples.UnloadableArchetypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Meep.Tech.XBam.Tests {
  public partial class Archetype {

    [TestClass]
    public class Loading {

      [AssemblyInitialize]
      public static void Initialize(TestContext _) {
        Loader.Settings settings = new() {
          UniverseName = "Meep.Tech.ECSBAM.Tests",
          PreLoadAssemblies = new() {
            typeof(Meep.Tech.XBam.Examples.ModelWithArchetypes.Apple).Assembly
          },
          FatalDuringFinalizationOnCouldNotInitializeTypes = true
        };

        new Loader(settings)
          .Initialize();
      }

      [TestMethod]
      public void LoadTypeAfterSealing_Success() {
        BeefJerkey newType = new BeefJerkey();
        string _ = newType.ToString();
        Assert.IsNotNull(Item.Types.Get<BeefJerkey>());
      }

      [TestMethod]
      public void LoadTypeAfterSealingEqual_Success() {
        Meep.Tech.XBam.Archetype newType = new BeefJerkey();
        Assert.AreEqual(newType.Id, Item.Types.Get(newType.GetType()).Id);
      }

      [TestMethod]
      public void LoadTypeBeforeLoaded_Failure() {
        Assert.ThrowsException<System.Collections.Generic.KeyNotFoundException>(
         () => Item.Types.Get<BeefJerkey>()
        );
      }

      [TestMethod]
      public void LoadTypeAfterSealing_Failure() {
        Assert.ThrowsException<System.InvalidOperationException>(
         () => new Apple("")
        );
      }

      [TestMethod]
      public void SplayedTypesLoadedOnInitialization_Success() {
        Assert.AreEqual(
          FruitType.Apple,
          (XBam.Archetype.ISplayed<FruitType, Sticker.Type>
            .GetForValue(FruitType.Apple)
            as XBam.Archetype.ISplayed<FruitType,Sticker.Type>)
              .AssociatedEnum
        );
      }

      [TestMethod]
      public void AllSplayedTypesLoaded_Success() {
        Assert.AreEqual(
          Archetypes.DefaultUniverse.Enumerations.GetAllByType(typeof(FruitType)).Count()
          + Archetypes.DefaultUniverse.Enumerations.GetAllByType(typeof(TreeType)).Count(),
          Archetypes.DefaultUniverse.Archetypes.TryToGetCollection(typeof(Sticker.Type)).Count()
        );
      }
    }
  }
}
