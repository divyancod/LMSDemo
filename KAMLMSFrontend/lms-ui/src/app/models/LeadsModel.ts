export interface LeadInformation {
    id: string;
    parentEnterpriseName: string;
    companyName: string;
    companyEmail: string;
    companyAddress: string;
    country: string;
    timeZone: string;
    workingHourStart: string;
    workingHourEnd: string;
    comment: string;
    addedBy: string | null;
    addedById: string;
    assignedTo: string | null;
    assignedToId: string;
    createdAt: string;
    modifiedAt: string;
  }
  
  export interface POCRoles
  {
    id:string;
    name:string;
  }

  export interface LeadTypes
  {
    id:string;
    status:string;
  }
 
  export interface SingleLead {
    id: string;
    companyName: string;
    enterpriseName: string;
    assignedTo: string;
    status: string;
    statusId: number;
}

export interface StatusGroup {
    id: number;
    status: string;
    leads: SingleLead[];
}

export interface LeadManagement {
    data: StatusGroup[];
}

export interface TimezoneInfo {
  id: number;
  country: string;
  timeZoneAbbreviation: string;
  utcOffset: string;
}
