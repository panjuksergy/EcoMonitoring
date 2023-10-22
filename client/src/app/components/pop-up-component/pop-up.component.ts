import { Component, Input, Output, EventEmitter } from '@angular/core';
import {CreateEcoRecordlModel} from "../new-url-component/models/create-eco-recordl.model";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-pop-up-component',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.scss']
})
export class PopUpComponent {
  @Input() shownText = '';
  @Input() withDT: boolean = false;
  @Output() closeOverlay = new EventEmitter<void>();
  @Output() onOkeyInput = new EventEmitter<string>();

  @Output() onSubmit = new EventEmitter<FormGroup>(); // Emit the form group

  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      suspendedSolids: '',
      sulfurDioxide: '',
      carbonDioxide: '',
      nitrogenDioxide: '',
      hydrogenFluoride: '',
      ammonia: '',
      formaldehyde: ''
    });
  }

  onCloseOverlay() {
    this.closeOverlay.emit();
  }

  onSubmitForm() {
      this.onSubmit.emit(this.form.value);
  }
}
