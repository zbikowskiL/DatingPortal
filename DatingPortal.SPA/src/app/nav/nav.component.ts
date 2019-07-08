import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(private athService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    return this.athService.login(this.model).subscribe(() => {
      this.alertify.success('Loggin complete!');
    }, error => {
      this.alertify.error('Loggin error!');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Logout complete!');
  }
}
