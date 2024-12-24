interface Role {
    id: number;
    name: string;
}

interface CustomRole {
    id: number;
    name: string;
}

export interface POCDetails {
    id: string;
    leadsId: string;
    name: string;
    phone: string;
    email: string;
    role: Role;
    roleId: number;
    customRoleId: number;
    customRole: CustomRole;
    createdAt: string;
    updatedAt: string;
    addedById: string;
}