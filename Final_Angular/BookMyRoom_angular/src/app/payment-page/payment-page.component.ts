import { UserService } from 'src/app/shared/user.service';
import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup,FormControl ,Validators} from '@angular/forms';
import { Form } from "@angular/forms";
import{Router} from'@angular/router';
import Swal from 'sweetalert2';
import { NgForm } from '@angular/forms';
import { ConfirmBooking } from "src/app/shared/confirm-booking.model";
import { User } from "src/app/shared/user.model";

@Component({
  selector: 'app-payment-page',
  templateUrl: './payment-page.component.html',
  styleUrls: ['./payment-page.component.css'],
 
})

export class PaymentPageComponent implements OnInit {

  constructor(public router:Router,public userservice:UserService ) { }
  CreditCardNumberPattern="^[0-9]{16}$";
  CvvPattern="^[0-9]{3}$";
 LoggedUser:User;
  public book: ConfirmBooking; 
  ngOnInit() {
    this.resetCreditForm();
    this.resetDebitForm();
  }


  resetCreditForm(Form?:NgForm)
  {
    if(Form!=null)
      {
        Form.resetForm();
      }
  }

  resetDebitForm(Form2?:NgForm)
  {
    if(Form2!=null)
      {
        Form2.resetForm();
      }
  }
  
  onSubmitCredit(Form:NgForm)
  {
    this.resetCreditForm();
    Swal({
      title: '<strong>Payment Accepted!</strong>',
      type: 'success',
      confirmButtonText:
      '<i class="fa fa-thumbs-up"></i> OK',
    })
    this.book = new ConfirmBooking();
    this.book=JSON.parse(sessionStorage.getItem('booking'));
this.LoggedUser=JSON.parse(sessionStorage.getItem('userrewards'));
this.userservice.Confirmbooking(this.book).subscribe(data => {
  if (data) {
    this.userservice.RoomBookingMapping(this.book).subscribe();
     
   this.userservice.updaterewards(this.LoggedUser).subscribe();
   
  Swal({
  title: 'Booking is Confirmed',
  type: 'success',
  confirmButtonColor: '#3085d6',
  confirmButtonText: 'Ok'
  }).then((result) => {
  if (result.value) {
  if(localStorage.getItem('loggingdetails')!=null)
  {
  this.userservice.LoggedUserDetails();
  }
  else{
  this.userservice.SocialloginUser(this.LoggedUser).subscribe((x: User) => {
  localStorage.setItem('currentuser', JSON.stringify(x));
  })
  }
  
  }
  })
  }
  else{
  Swal("Booking is failed");
  
  }
  })
    this.router.navigate(['/Search']);
  }

  onSubmitDebit(Form2:NgForm)
  {
    
      this.resetDebitForm();
      Swal({
        title: '<strong>Payment Accepted!</strong>',
        type: 'success',
        confirmButtonText:
        '<i class="fa fa-thumbs-up"></i> OK',
      })
      this.router.navigate(['/Search']);
   
  }
}
