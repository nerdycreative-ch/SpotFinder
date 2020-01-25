import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { LoginViewModel } from '../_ViewModels/LoginViewModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loginError: string = null;

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    });

    this.loginForm.valueChanges.subscribe((value) => {
      //console.log(value);
    });
  }

  onSubmitClick() {
    this.loginForm["submitted"] = true;

    if (this.loginForm.valid) {
      var loginVieModel = this.loginForm.value as LoginViewModel;
      this.authService.login(loginVieModel).subscribe(
        (response) => {
          this.router.navigate(["home"]);
        },
        (error) => {
          this.loginError = "Username or password is incorrect";
        });
    }

  }

}
