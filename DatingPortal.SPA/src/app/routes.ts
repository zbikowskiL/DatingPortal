import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { LikesComponent } from './likes/likes/likes.component';
import { MessagesComponent } from './messages/messages/messages.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'users', component: UsersListComponent },
  { path: 'likes', component: LikesComponent },
  { path: 'messages', component: MessagesComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
