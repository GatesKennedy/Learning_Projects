namespace LMS_Population.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BooleanQuestions",
                c => new
                    {
                        BooleanQuestionId = c.String(nullable: false, maxLength: 128),
                        PageId = c.String(),
                        PageFieldId = c.String(),
                        Question = c.String(),
                        OptionalText = c.String(),
                        QuestionNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BooleanQuestionId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(),
                        CourseDescription = c.String(),
                        DaysToComplete = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Core = c.Boolean(nullable: false),
                        UniversityOfConcordia = c.Boolean(nullable: false),
                        FreeCourse = c.Boolean(nullable: false),
                        SandBox = c.Boolean(nullable: false),
                        TechAcademy = c.Boolean(nullable: false),
                        CoursePosition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.String(),
                        PageNumber = c.Int(),
                        IsTest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.PageFields",
                c => new
                    {
                        PageFieldId = c.String(nullable: false, maxLength: 128),
                        PageId = c.String(),
                        BooleanQuestionId = c.String(),
                        FieldType = c.String(nullable: false),
                        Content = c.String(),
                        FinalEssay = c.Boolean(nullable: false),
                        FieldNumber = c.Int(nullable: false),
                        FieldTitle = c.String(nullable: false),
                        FieldReference = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PageFieldId);
            
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        QuestionChoiceId = c.String(nullable: false, maxLength: 128),
                        TestQuestionId = c.String(),
                        BooleanQuestionId = c.String(),
                        Choice = c.String(),
                        CorrectChoice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionChoiceId);
            
            CreateTable(
                "dbo.TabFields",
                c => new
                    {
                        TabFieldId = c.String(nullable: false, maxLength: 128),
                        PageId = c.String(),
                        PageFieldId = c.String(),
                        TabNumber = c.Int(nullable: false),
                        TabName = c.String(nullable: false),
                        Heading = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.TabFieldId);
            
            CreateTable(
                "dbo.TestAnswers",
                c => new
                    {
                        TestAnswerId = c.String(nullable: false, maxLength: 128),
                        StudentTestResultId = c.String(),
                        TestQuestionId = c.String(),
                        Response = c.String(),
                        Correct = c.Boolean(nullable: false),
                        AnsweredOnTest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TestAnswerId);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        TestQuestionId = c.String(nullable: false, maxLength: 128),
                        PageId = c.String(),
                        Question = c.String(),
                        OptionalText = c.String(),
                        QuestionNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestQuestionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestQuestions");
            DropTable("dbo.TestAnswers");
            DropTable("dbo.TabFields");
            DropTable("dbo.QuestionChoices");
            DropTable("dbo.PageFields");
            DropTable("dbo.Pages");
            DropTable("dbo.Courses");
            DropTable("dbo.BooleanQuestions");
        }
    }
}
