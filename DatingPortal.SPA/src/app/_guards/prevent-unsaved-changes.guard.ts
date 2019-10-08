import { CanDeactivate } from '@angular/router';
import { UserEditComponent } from '../users/user-edit/user-edit.component';

export class PreventUnsavedChanges implements CanDeactivate<UserEditComponent> {
  canDeactivate(component: UserEditComponent) {
    if (component.editForm.dirty) {
      return confirm('Are you sure that you want cotinue? All data will be lost!');
    }
    return true;
  }
}
