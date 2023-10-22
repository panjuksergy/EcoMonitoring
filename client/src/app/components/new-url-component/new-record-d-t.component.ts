import { Component, EventEmitter, Output } from '@angular/core';
import {NewEcoRecordService} from "./services/new-eco-record.service";
import {CreateEcoRecordlModel} from "./models/create-eco-recordl.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-new-record-component',
  templateUrl: './new-record-d-t.component.html',
  styleUrls: ['./new-record-d-t.component.scss']
})
export class NewRecordDTComponent {
  @Output() closeOverlay = new EventEmitter<void>();
  textToShown = 'Enter new ECO record';
  constructor(private newUrlService: NewEcoRecordService, private router: Router)
  {}
  onCloseOverlay() {
    this.closeOverlay.emit();
  }

  async generateNewEcoRecord(data: any) {
    this.newUrlService.createNewEcoRecord(data).subscribe((ok:boolean) => {});
    setTimeout(() => {
      const currentUrl = this.router.url;
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigateByUrl(currentUrl);
      });
    },500);
  }

  protected readonly onsubmit = onsubmit;
}
