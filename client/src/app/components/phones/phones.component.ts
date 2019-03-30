import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PhonesService } from '../../services/phones.service';
import { Phone } from '../../models/phone';

@Component({
  selector: 'app-phones',
  templateUrl: './phones.component.html',
  styleUrls: ['./phones.component.scss']
})
export class PhonesComponent implements OnInit {

  allPhones: Observable<Phone[]>;

  constructor( private pS: PhonesService) { }

  ngOnInit() {
    this.loadAllPhones();
  }

  loadAllPhones() {
    this.allPhones = this.pS.getAllPhones();
  }

  deleteWorker(phoneId: string) {
    if (confirm('Are you sure you want to delete this ?')) {
      this.pS.deletePhoneById(phoneId).subscribe(() => {
        this.loadAllPhones();
      });
    }
  }
}
