import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Country} from '../models/country.model';
import {environment} from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class CountryService {

    baseUrl = environment.baseUrl + 'country/all';

    constructor(private httpClient: HttpClient) {
    }

    all(): Observable<Country[]> {
      return this.httpClient.get<Country[]>(this.baseUrl);
    }
}
