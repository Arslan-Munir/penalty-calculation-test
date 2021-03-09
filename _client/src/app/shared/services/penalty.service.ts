import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {CalculatePenalty} from '../models/calculate-penalty.model';
import {environment} from '../../../environments/environment';
import {CalculatedPenalty} from '../models/calculated-penalty.model';

@Injectable({
    providedIn: 'root'
})
export class PenaltyService {

    private baseUrl = environment.baseUrl + 'penalty/';

    constructor(private httpClient: HttpClient) {
    }

    calculate(calculatePenalty: CalculatePenalty): Observable<CalculatedPenalty> {
        return this.httpClient.post<CalculatedPenalty>(this.baseUrl, calculatePenalty);
    }
}
