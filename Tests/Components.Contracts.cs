﻿using Meep.Tech.XBam.Examples.ModelWithComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Components {
    [TestClass]
    public class Contracts {

      [TestMethod]
      public void TestContractExecuted_CapacitorFirst_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();

        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        machine.AddComponent(capacitor);

        CapacitorDetector detector = Components<CapacitorDetector>.Factory.Make();
        machine.AddComponent(detector);

        Assert.IsTrue(detector.CapacitorWasDetected);
      }

      [TestMethod]
      public void TestContractExecuted_CapacitorSecond_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();

        CapacitorDetector detector = Components<CapacitorDetector>.Factory.Make();
        machine.AddComponent(detector);
        
        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        machine.AddComponent(capacitor);

        Assert.IsTrue(detector.CapacitorWasDetected);
      }

      [TestMethod]
      public void TestContractExecuted_MultiComponentContracts_First_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();

        MultiComponentDetector detector = Components<MultiComponentDetector>.Factory.Make();
        machine.AddComponent(detector);
        
        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        machine.AddComponent(capacitor);

        Assert.IsTrue(detector.CapacitorWasDetected);
      }

      [TestMethod]
      public void TestContractExecuted_MultiComponentContracts_FirstAndSecond_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();

        MultiComponentDetector detector = Components<MultiComponentDetector>.Factory.Make();
        machine.AddComponent(detector);
        
        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        machine.AddComponent(capacitor);
        DisplayComponent display = Components<DisplayComponent>.Factory.Make();
        machine.AddComponent(display);

        Assert.IsTrue(detector.CapacitorWasDetected && detector.DisplayComponentWasDetected);
      }

      [TestMethod]
      public void TestContractExecuted_MultiComponentContracts_Second_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();
        
        MultiComponentDetector detector = Components<MultiComponentDetector>.Factory.Make();
        machine.AddComponent(detector);
        
        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        machine.AddComponent(capacitor);
        DisplayComponent display = Components<DisplayComponent>.Factory.Make();
        machine.AddComponent(display);

        Assert.IsTrue(detector.DisplayComponentWasDetected);
      }

      [TestMethod]
      public void TestContractExecuted_MultiComponentContracts_FirstAndSecond_DetectorLast_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();
        
        MultiComponentDetector detector = Components<MultiComponentDetector>.Factory.Make();
        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        DisplayComponent display = Components<DisplayComponent>.Factory.Make();

        machine.AddComponent(capacitor);
        machine.AddComponent(display);
        machine.AddComponent(detector);


        Assert.IsTrue(detector.CapacitorWasDetected);
      }

      [TestMethod]
      public void TestContractExecuted_MultiComponentContracts_FirstAndSecond_DetectorMiddle_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();
        
        MultiComponentDetector detector = Components<MultiComponentDetector>.Factory.Make();
        CapacitorData capacitor = Components<CapacitorData>.Factory.Make(
          (nameof(CapacitorData.Value), 103)  
        );
        DisplayComponent display = Components<DisplayComponent>.Factory.Make();

        machine.AddComponent(capacitor);
        machine.AddComponent(detector);
        machine.AddComponent(display);


        Assert.IsTrue(detector.CapacitorWasDetected);
      }

      [TestMethod]
      public void TestContractNotExecuted_CapacitorNotAdded_Success() {
        var machine = Device.Types.Get<DangerousModularDevice.Type>()
          .GetDefaultBuilders().Make<DangerousModularDevice>();

        CapacitorDetector detector = Components<CapacitorDetector>.Factory.Make();
        machine.AddComponent(detector);

        Assert.IsFalse(detector.CapacitorWasDetected);
      }
    }
  }
}
