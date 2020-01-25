import { Injectable } from '@angular/core';
import { ValidatorFn, ValidationErrors, FormGroup, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CustomValidatorsService {

  constructor(private authService: AuthService) { }

  public compareValidator(controlToValidate: string, controlToCompare: string): ValidatorFn {
    return (formGroup: FormGroup): ValidationErrors | null => {
      if (!formGroup.get(controlToValidate).value)
        return null; //return, if the confirm password is null

      if (formGroup.get(controlToValidate).value == formGroup.get(controlToCompare).value)
        return null; //valid
      else {
        formGroup.get(controlToValidate).setErrors({ compareValidator: { valid: false } });
        return { compareValidator: { valid: false } }; //invalid
      }
    };
  }

  public DuplicateEmailValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.authService.getUserByEmail(control.value).pipe(map((existingUser: any) => {
        if (existingUser == true) {
          return { uniqueEmail: { valid: false } }; //invalid
        }
        else {
          return null;
        }
      }));
    };
  }

}
