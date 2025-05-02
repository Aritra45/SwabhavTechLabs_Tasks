import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminServiceService } from '../../admin-service.service';

@Component({
  selector: 'app-remove-admin',
  standalone: false,
  templateUrl: './remove-admin.component.html',
  styleUrl: './remove-admin.component.css'
})
export class RemoveAdminComponent {
  displayedColumns: string[] = ['index', 'userName', 'userEmail', 'action'];

  constructor(@Inject(MAT_DIALOG_DATA) public getData: any, private removeAdmin: AdminServiceService) { }

  deleteAdmin(email: string, name: string) {
    const val = confirm("Are You Sure?")
    if (val == true) {
      this.removeAdmin.removeAdminAccess(email)
        .subscribe(
          (response) => {
            console.log("Success:", response);
            alert(`Admin ${name} removed successfully.`);

            // Remove the deleted admin from the list
            this.getData = this.getData.filter((admin: any) => admin.userEmail !== email);
          },
          (error) => {
            console.error("Error:", error);
            alert(`Error: ${error.message || 'Something went wrong'}`);
          }
        );
    }
    else {
      alert("Task Dismiss!!!")
    }
  }
}
