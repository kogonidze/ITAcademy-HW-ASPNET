import { Category } from "../../enums/category";
import { Formation } from "../../enums/formation";
import { Department } from "../department/department.model";


export interface Teacher {
    id: number,
    fio: string,
    dateOfBirth: Date,
    departmentId: number | null,
    department: Department,
    experience: number,
    category: Category,
    formation: Formation
}