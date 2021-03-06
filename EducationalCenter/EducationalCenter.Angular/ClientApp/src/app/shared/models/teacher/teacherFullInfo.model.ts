import { Category } from "../../enums/category";
import { Formation } from "../../enums/formation";

export interface TeacherFullInfo {
    id: number,
    firstName: string,
    lastName: string,
    dateOfBirth: Date,
    eMail: string,
    phoneNumber: string,
    departmentId: number | null,
    experience: number,
    category: Category,
    formation: Formation,
    salary: number
}