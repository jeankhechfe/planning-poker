import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../auth/user.service';
import {first} from 'rxjs/operators';
import {Router} from '@angular/router';
import { User } from '../_model/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder,
    private user: User,
  ) {

  }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  get f() { return this.registerForm.controls; }


  onSubmit(){
    this.user.login = this.registerForm.value.username;
    this.userService.register(this.user)
      .pipe(first())
      .subscribe(
        _ => {
          console.log('success');
          this.router.navigate(['/login']);
        },
        error => {
          console.log('error');
          // TODO alert
          this.loading = false;
        }
      );
  }
}
