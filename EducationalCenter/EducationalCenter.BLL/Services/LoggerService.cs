using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Dtos.User;
using EducationalCenter.Common.Enums;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;

namespace EducationalCenter.BLL.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IHttpContextAccessor _accessor;

        public LoggerService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void GenerateRequestLog<TRequest>(TRequest? newRequest, LogType logType)
        {
            FillUserInfoInLogContext(logType);

            switch (logType)
            {
                case LogType.Exception:
                    break;

                case LogType.RegistrationRequest:
                    {
                        var request = newRequest as UserRegistrationDto;

                        Log.Information($"Registration request with login: {request?.EMail} from IP: {_accessor.HttpContext.Request.Host}");
                        break;
                    }

                case LogType.AuthorizationRequest:
                    {
                        var request = newRequest as UserForAuthenticationDto;
                        LogContext.PushProperty(PropertyNames.Password, request?.Password);

                        Log.Information($"Authorization request with login: {request?.EMail} from IP: {_accessor.HttpContext.Request.Host}");
                        break;
                    }


                case LogType.StudentIndexingRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to get list of students");
                        break;
                    }

                case LogType.StudentInfoRequest:
                    {
                        var studentId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to get info about student with id {studentId}");
                        break;
                    }

                case LogType.StudentCreationRequest:
                    {
                        var request = newRequest as StudentCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to create new student {request.LastName}");
                        break;
                    }

                case LogType.StudentEditionRequest:
                    {
                        var request = newRequest as StudentFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to edit student with id {request.Id}");
                        break;
                    }

                case LogType.StudentDeletionRequest:
                    {
                        var studentId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to delete student with id {studentId}");
                        break;
                    }

                case LogType.TeacherIndexingRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to get list of teachers");
                        break;
                    }

                case LogType.TeacherInfoRequest:
                    {
                        var teacherId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to get info about teacher with id {teacherId}");
                        break;
                    }

                case LogType.TeacherCreationRequest:
                    {
                        var request = newRequest as TeacherCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to create new teacher {request.LastName}");
                        break;
                    }

                case LogType.TeacherEditionRequest:
                    {
                        var request = newRequest as TeacherFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to edit teacher with id {request.Id}");
                        break;
                    }

                case LogType.TeacherDeletionRequest:
                    {
                        var teacherId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to delete teacher with id {teacherId}");
                        break;
                    }

                case LogType.StudentGroupIndexingRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to get list of student groups");
                        break;
                    }

                case LogType.StudentGroupCreationRequest:
                    {
                        var request = newRequest as StudentGroupCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to create new student group {request.Title}");
                        break;
                    }

                case LogType.StudentGroupEditionRequest:
                    {
                        var request = newRequest as StudentGroupFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to edit student group with id {request.Id}");
                        break;
                    }

                case LogType.StudentGroupDeletionRequest:
                    {
                        var studentGroupId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to delete student group with id {studentGroupId}");
                        break;
                    }

                case LogType.CoursesCreationRequest:
                    {
                        var request = newRequest as CourseCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to create new course {request.Title}");
                        break;
                    }

                case LogType.CoursesEditionRequest:
                    {
                        var request = newRequest as CourseFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to edit course with id {request.Id}");
                        break;
                    }

                case LogType.CoursesDeletionRequest:
                    {
                        var courseId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to delete course with id {courseId}");
                        break;
                    }

                case LogType.DepartmentCreationRequest:
                    {
                        var request = newRequest as DepartmentCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to create new department {request.Name}");
                        break;
                    }

                case LogType.DepartmentEditionRequest:
                    {
                        var request = newRequest as DepartmentDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to edit department with id {request.Id}");
                        break;
                    }

                case LogType.DepartmentDeletionRequest:
                    {
                        var departmentId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to delete department with id {departmentId}");
                        break;
                    }

                case LogType.FacultyCreationRequest:
                    {
                        var request = newRequest as FacultyCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to create new faculty {request.Name}");
                        break;
                    }

                case LogType.FacultyEditionRequest:
                    {
                        var request = newRequest as FacultyDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to edit faculty with id {request.Id}");
                        break;
                    }

                case LogType.FacultyDeletionRequest:
                    {
                        var facultyId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is trying to delete faculty with id {facultyId}");
                        break;
                    }

                case LogType.TeacherSearchRequest:
                    {
                        var request = newRequest as GetFilteredTeachersRequest;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} is started the search of teachers with criteriums: " +
                            $"1. fio {request.FIO}, 2. min experience {request.Experience}, 3.min category {request.Category} " +
                            $"4. min formation {request.Formation}");

                        break;
                    }

                default:
                    break;
            }
        }

        public void GenerateResponseLog<TRequest, TResponse>(TRequest newRequest, TResponse newResponse, LogType logType)
        {
            FillUserInfoInLogContext(logType);

            switch (logType)
            {
                case LogType.Exception:
                    break;

                case LogType.RegistrationRequest:
                    {
                        var request = newRequest as UserRegistrationDto;

                        Log.Information($"User {request.EMail} successfully registered in system!");
                        break;
                    }

                case LogType.AuthorizationRequest:
                    {
                        var request = newRequest as UserForAuthenticationDto;

                        Log.Information($"User {request.EMail} successfully authorized in system!");
                        break;
                    }

                case LogType.StudentIndexingRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} has get list of students!");

                        break;
                    }

                case LogType.StudentInfoRequest:
                    {
                        var studentId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} has got info about student with id {studentId}");
                        break;
                    }

                case LogType.StudentCreationRequest:
                    {
                        var request = newRequest as StudentCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} created new student {request.LastName}");
                        break;
                    }

                case LogType.StudentEditionRequest:
                    {
                        var request = newRequest as StudentFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} edited student with id {request.Id}");
                        break;
                    }


                case LogType.StudentDeletionRequest:
                    {
                        var studentId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} deleted student with id {studentId}");
                        break;
                    }

                case LogType.TeacherIndexingRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} has got list of teachers");
                        break;
                    }

                case LogType.TeacherInfoRequest:
                    {
                        var teacherId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} has got info about teacher with id {teacherId}");
                        break;
                    }

                case LogType.TeacherCreationRequest:
                    {
                        var request = newRequest as TeacherCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} created new teacher {request.LastName}");
                        break;
                    }

                case LogType.TeacherEditionRequest:
                    {
                        var request = newRequest as TeacherFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} edited teacher with id {request.Id}");
                        break;
                    }

                case LogType.TeacherDeletionRequest:
                    {
                        var teacherId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} deleted teacher with id {teacherId}");
                        break;
                    }

                case LogType.StudentGroupIndexingRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} has got list of student groups");
                        break;
                    }
                   

                case LogType.StudentGroupCreationRequest:
                    {
                        var request = newRequest as StudentGroupCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} created new student group {request.Title}");
                        break;
                    }

                case LogType.StudentGroupEditionRequest:
                    {
                        var request = newRequest as StudentGroupFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} edited student group with id {request.Id}");
                        break;
                    }

                case LogType.StudentGroupDeletionRequest:
                    {
                        var studentGroupId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} deleted student group with id {studentGroupId}");
                        break;
                    }

                case LogType.CoursesCreationRequest:
                    {
                        var request = newRequest as CourseCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} created new course {request.Title}");
                        break;
                    }

                case LogType.CoursesEditionRequest:
                    {
                        var request = newRequest as CourseFullInfoDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} edited course with id {request.Id}");
                        break;
                    }

                case LogType.CoursesDeletionRequest:
                    {
                        var courseId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} deleted course with id {courseId}");
                        break;
                    }

                case LogType.DepartmentCreationRequest:
                    {
                        var request = newRequest as DepartmentCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} created new department {request.Name}");
                        break;
                    }

                case LogType.DepartmentEditionRequest:
                    {
                        var request = newRequest as DepartmentDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} edited department with id {request.Id}");
                        break;
                    }

                case LogType.DepartmentDeletionRequest:
                    {
                        var departmentId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} deleted department with id {departmentId}");
                        break;
                    }

                case LogType.FacultyCreationRequest:
                    {
                        var request = newRequest as FacultyCreationDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} created new faculty {request.Name}");
                        break;
                    }

                case LogType.FacultyEditionRequest:
                    {
                        var request = newRequest as FacultyDTO;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} edited faculty with id {request.Id}");
                        break;
                    }

                case LogType.FacultyDeletionRequest:
                    {
                        var facultyId = newRequest as int?;

                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} deleted faculty with id {facultyId}");
                        break;
                    }

                case LogType.TeacherSearchRequest:
                    {
                        Log.Information($"User {_accessor.HttpContext.User.Identity.Name} has got results of the search");
                        break;
                    }

                default:
                    break;
            }
        }

        private void FillUserInfoInLogContext(LogType logType)
        {
            LogContext.PushProperty(PropertyNames.IP, _accessor.HttpContext.Request.Host);
            LogContext.PushProperty(PropertyNames.UserName, _accessor.HttpContext.User.Identity.Name);
            LogContext.PushProperty(PropertyNames.LogType, (long)logType);
        }
    }
}
