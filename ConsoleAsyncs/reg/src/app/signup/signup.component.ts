import { Component, OnInit } from '@angular/core';
import {UserService } from '../shared/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  
  constructor(private userService:UserService, private toastr: ToastrService) { }
  emailPattern="^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  mobPattern="[789][0-9]{9}";

  ngOnInit() {
   this.resetForm();
  //  Swal({
  //   title: 'Are you sure?',
  //   text: "You won't be able to revert this!",
  //   type: 'warning',
  //   showCancelButton: true,
  //   confirmButtonColor: '#3085d6',
  //   cancelButtonColor: '#d33',
  //   confirmButtonText: 'Yes, delete it!'
  // }).then((result) => {
  //   if (result.value) {
  //     this.router.navigate(['/register-step2']);
  //   }
  // })
   
  
  }
  resetForm(form? : NgForm)
  {
    if(form != null)
     form.reset();
     this.userService.selectedUser={
      Name: '',
      Email: '',
      Password: '',
      Gender:'',
      Age:null,
      Mobile_no:''
  
     }
    
    }
    onSubmit(form :NgForm)
    {
      this.userService.postUser(form.value)
      .subscribe( data =>{
        this.resetForm(form);
       
      })
      Swal({
        title: '<strong>Registration Successful</strong>',
        type: 'info',
        html:
          'You can use <b>bold text</b>, ' +
          '<a href="//github.com">links</a> ' +
          'and other HTML tags',
        showCloseButton: true,
        showCancelButton: true,
        focusConfirm: false,
        confirmButtonText:
          '<i class="fa fa-thumbs-up"></i> Great!',
        confirmButtonAriaLabel: 'Thumbs up, great!',
        cancelButtonText:
          '<i class="fa fa-thumbs-down"></i>',
        cancelButtonAriaLabel: 'Thumbs down',
        
      });
    }
}
