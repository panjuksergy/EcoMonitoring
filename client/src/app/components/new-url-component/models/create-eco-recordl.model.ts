export class CreateEcoRecordlModel {
  suspendedSolids: string;
  sulfurDioxide: string;
  carbonDioxide: string;
  nitrogenDioxide: string;
  hydrogenFluoride: string;
  ammonia: string;
  formaldehyde: string;

  constructor(
    suspendedSolids: string,
    sulfurDioxide: string,
    carbonDioxide: string,
    nitrogenDioxide: string,
    hydrogenFluoride: string,
    ammonia: string,
    formaldehyde: string
  ) {
    this.suspendedSolids = suspendedSolids;
    this.sulfurDioxide = sulfurDioxide;
    this.carbonDioxide = carbonDioxide;
    this.nitrogenDioxide = nitrogenDioxide;
    this.hydrogenFluoride = hydrogenFluoride;
    this.ammonia = ammonia;
    this.formaldehyde = formaldehyde;
  }
}
