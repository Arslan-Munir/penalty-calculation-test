import {Component, OnInit} from '@angular/core';
import {CountryService} from './shared/services/country.service';
import {Country} from './shared/models/country.model';
import {CalculatePenalty} from './shared/models/calculate-penalty.model';
import {PenaltyService} from './shared/services/penalty.service';
import {CalculatedPenalty} from './shared/models/calculated-penalty.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PenaltyCalculation-SPA';
  showPenalty = false;
  countries = new Array<Country>();
  calculatePenalty = new CalculatePenalty();
  calculatedPenalty = new CalculatedPenalty();

  constructor(private countryService: CountryService, private penaltyService: PenaltyService) {
  }

  ngOnInit(): void {
    this.countryService.all()
      .subscribe((countries) => {
        this.countries = countries;
        console.log(this.countries);
      }, (error) => {
        console.log(error);
      });
  }

  calculate() {
    this.penaltyService.calculate(this.calculatePenalty)
      .subscribe((calculatedPenalty) => {
        this.showPenalty = true;
        this.calculatedPenalty = calculatedPenalty;
      }, (error) => {
        console.log(error);
      });
  }
}
