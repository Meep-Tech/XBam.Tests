﻿using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Meep.Tech.XBam.Examples.ModelWithComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Archetype {
    public partial class Collection {
      /// <summary>
      /// Ways to get/access Archetype.Collections
      /// </summary>
      [TestClass]
      public class Get {

        // TODO: test child archetypes and models that have a new type of collection.

        [TestMethod]
        public void StaticFromChildArchetype_Exists() {
          Assert.IsNotNull(Archetypes.GetCollectionFor(Archetypes<Apple>._));
        }

        [TestMethod]
        public void StaticCollectionFromBaseArchetype_Exists() {
          Assert.IsNotNull(Archetypes<Apple>.Collection);
        }

        [TestMethod]
        public void StaticCollectionFromBaseArchetype_Equals() {
          Assert.IsNotNull(Archetypes<Apple>.Collection);
          Assert.IsNotNull(Archetypes<Sword>.Collection);
        }

        [TestMethod]
        public void StaticCollectionFromBaseArchetype_NotEquals() {
          Assert.IsNotNull(Archetypes<Apple>.Collection);
          Assert.IsNotNull(Archetypes<ModularFluxCapacitor.Type>.Collection);
        }

        [TestMethod]
        public void StaticCollectionFromChildArchetype_Exists() {
          Assert.IsNotNull(Archetypes<Apple>.Collection);
        }

        [TestMethod]
        public void DefaultTypesCollectionForBaModel_Exists() {
          Assert.IsNotNull(Item.Types);
        }
      }
    }
  }
}
