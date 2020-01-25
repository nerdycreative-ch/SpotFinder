import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidatorsService } from '../custom-validators.service';
import { AuthService } from '../auth.service';
import { RegisterViewModel } from '../_ViewModels/RegisterViewModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  registerError: string = null;

  constructor(private formBuilder: FormBuilder, private router: Router,
    private customValidatorsService: CustomValidatorsService, private authService: AuthService) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email], [this.customValidatorsService.DuplicateEmailValidator()], { updateOn: 'blur' }],
      password: [null, [Validators.required, Validators.minLength(6)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(6)]],
    },
      {
      validators: [
        this.customValidatorsService.compareValidator("confirmPassword", "password")
      ]
      });

    this.registerForm.valueChanges.subscribe((value) => {
      //console.log(value);
    });
  }

  onSubmitClick() {
    this.registerForm["submitted"] = true;

    if (this.registerForm.valid) {
      var registerVieModel = this.registerForm.value as RegisterViewModel;
      this.authService.Register(registerVieModel).subscribe(
        (response) => {
          this.router.navigate(["confirmEmail"]);
        },
        (error) => {
          this.registerError = "Unable to submit";
        });
    }

    
  }

}
