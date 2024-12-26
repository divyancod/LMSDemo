export interface CallScheduledResponse {
    callScheduleId: string;
    scheduledWithName: string;
    scheduledWithPhone: string;
    scheduledByName: string;
    callerName: string;
    scheduledAt: string; 
    comment: string | null;
    callStatusId: number;
    callStatusName: string;
}

export interface CallStatusModel
{
    id:number;
    status:string;
}

export interface FilterCallStatusModel
{
    callStatusModel:CallStatusModel,
    isSelected:boolean;
}