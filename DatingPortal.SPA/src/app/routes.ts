import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { LikesComponent } from './likes/likes/likes.component';
import { MessagesComponent } from './messages/messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { UserDetailResolver } from './_resolvers/user-details.resolver';
import { UsersListResolver } from './_resolvers/users-list.resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver copy';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'users', component: UsersListComponent, resolve: { users: UsersListResolver } },
      { path: 'user/:id', component: UserDetailsComponent, resolve: { user: UserDetailResolver } },
      {
        path: 'users/edit', component: UserEditComponent,
        resolve: { user: UserEditResolver },
        canDeactivate: [PreventUnsavedChanges]
      },
      { path: 'likes', component: LikesComponent },
      { path: 'messages', component: MessagesComponent },



    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
