import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-update-lead',
  templateUrl: './update-lead.component.html',
  styleUrls: ['./update-lead.component.css']
})
export class UpdateLeadComponent implements OnInit {

  comment:string = ''
  @Input("leadId")id:string = ''
  @Input("isWon")isWon:boolean = false;
  errorMessage:string=''
  wonMessage:string='Marking this lead as WON make all the calls cancel if you are still tracking this lead please keep it in In-progress state.'
  lostMessage:string = 'Too bad we lost this lead. Marking this lead as LOST will make all calls cancel if you still think you can follow up on this please keep it in In-progress state.'
  constructor(private leadsService:LeadsService,private activeModel:NgbActiveModal) { }

  ngOnInit(): void {
  }

  confirm()
  {
    if(this.comment.trim()=='')
    {
      this.errorMessage = 'Add comments'
      return;
    }
    var payload;
    if(this.isWon)
    {
      payload = {id:this.id,status:"4",comment:this.comment};
    }else
    {
      payload = {id:this.id,status:"5",comment:this.comment};
    }
    this.leadsService.updateLead(payload).subscribe(data=>{
      location.reload();
    })
  }
  cancel()
  {
    this.activeModel.close();
  }

}
