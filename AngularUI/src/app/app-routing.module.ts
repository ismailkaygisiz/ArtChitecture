import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './core/components/admin/dashboard/dashboard.component';
import { AuthComponent } from './core/components/auth/auth/auth.component';
import { LoginComponent } from './core/components/auth/login/login.component';
import { RegisterComponent } from './core/components/auth/register/register.component';
import { ErrorComponent } from './core/components/error/error.component';

import { LoginDisableGuard } from './core/guards/login-disable.guard';
import { LoginGuard } from './core/guards/login.guard';

import { AdminLayoutComponent } from './core/layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './core/layouts/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './core/layouts/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [],
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      { path: '', component: DashboardComponent, canActivate: [LoginGuard] }
    ],
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    children: [
      { path: '', component: AuthComponent },
      { path: 'login', component: LoginComponent, canActivate: [LoginDisableGuard] },
      { path: 'register', component: RegisterComponent, canActivate: [LoginDisableGuard] },
    ],
  },
  {
    path: '**',
    component: ErrorComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
